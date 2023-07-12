using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CustomersExercise.Application.Dto.Customer
{
    public class CreateCustomerDto
    {
        [JsonPropertyName("Firstname")]
        [MinLength(1)]
        public string Firstname { get; set; }

        [JsonPropertyName("Surname")]
        [MinLength(1)]
        public string Surname { get; set; }
    }
}
