using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = MockPerson();
            return persons;
        }


        public Person FindByID(long id)
        {
            var person = MockPerson();
            return person.FirstOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            return person;
        }

        private static List<Person> MockPerson()
        {
            return new List<Person>()
            {
                new Person { Id = 1, FirstName = "Douglas", LastName = "Ribeiro", Address = "São Paulo - SP - Brasil", Gender = "Male" },
                new Person { Id = 2, FirstName = "Rodrigo", LastName = "Ribeiro", Address = "São Paulo - SP - Brasil", Gender = "Male" },
                new Person { Id = 3, FirstName = "Priscila", LastName = "Maranha", Address = "Curitiba - PR - Brasil", Gender = "Female" }
            };
        }
    }
}
