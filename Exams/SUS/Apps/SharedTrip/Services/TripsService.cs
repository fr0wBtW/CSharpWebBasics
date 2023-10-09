using Microsoft.CodeAnalysis.CSharp.Syntax;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ApplicationDbContext db { get; }

        public bool AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return false;
            }
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };
            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
            return true;
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();
            var availableSeats = trip.Seats - trip.TakenSeats;
            return availableSeats > 0;
        }

        public void Create(AddTripInputModel trip)
        {
            var dbTrip = new Trip
            {
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = trip.Description,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                Seats = (byte)trip.Seats,
                StartPoint = trip.StartPoint
            };
            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new TripViewModel
            {
                Id = x.Id,
                DepartureTime = x.DepartureTime,
                EndPoint = x.EndPoint,
                StartPoint = x.StartPoint,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()
            }).ToList();
            return trips;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id).Select(x => new TripDetailsViewModel
            {
                Id = x.Id,
                DepartureTime = x.DepartureTime,
                Description = x.Description,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                ImagePath = x.ImagePath,
                Seats = x.Seats,
                UsedSeats = x.UserTrips.Count()

            }).FirstOrDefault();
            return trip;
        }
    }
}
