

namespace BookTheos.Application.DTOs.BookDTO
{
    public class ReadBookDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? synopsis { get; set; }

        public string? Author { get; set; }
    }
}
