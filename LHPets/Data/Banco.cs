using LHPets.Models;

namespace LHPets.Data
{
    public static class Banco
    {
        public static List<Cliente> Clientes { get; } = new();

        public static List<Pet> Pets { get; } = new();
    }
}