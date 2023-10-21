using MvcMovieRental.Models;

namespace MvcMovieRental.ViewModels
{
    public class RandomFilmViewModel
    {
        public Film Film { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
