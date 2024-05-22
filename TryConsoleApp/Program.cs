using ReflectiveMapper.DummyClasses;
using ReflectiveMapper.Implementations.Services;
using ReflectiveMapper.Interfaces.Services;
using ReflectiveMapper.Models;


namespace TryConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMapper mapper = new Mapper();
            Product p1 = new Product() { Id = Guid.NewGuid(), Name = "Product1", Quantity = 22 };
            ProductDto dto ;


            dto = mapper.Map<Product, ProductDto>(p1);


            Console.WriteLine(dto.Id);
            Console.WriteLine(dto.Name);
            Console.WriteLine(dto.Quantity);

        }





    }
}
