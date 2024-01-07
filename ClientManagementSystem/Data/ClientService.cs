using ClientManagementSystem.MyContext;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSystem.Data
{
	
	public class ClientService
    {
        private readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context) 
        {
            _context = context;
		}

		public async Task<List<Client>> GetAll()
		{
			try
			{
				return await _context.Clients.ToListAsync();
			}
			catch (Exception ex)
			{
				// Log or handle the exception as needed
				Console.WriteLine($"An error occurred while fetching clients: {ex.Message}");
				throw; // Re-throw the exception to maintain the original behavior
			}
		}

        public async Task CalculateAmountToPay(Client client)
        {
            if (client.AmountGiven.HasValue)
            {
                // Calculate the percentage of the rate
                double percentage = client.Rate / 100.0;

                // Calculate the AmountToPay
                double amountToPay = client.AmountGiven.Value * (1 + percentage);

                // Assign the calculated amount to the property
                client.AmmountToPay = amountToPay;

                // Update the client in the database
                await Update(client);
            }
        }


        public async Task<bool> Add(Client client)
		{
			try
			{
				// Validate client data here if needed

				await _context.Clients.AddAsync(client);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while adding a client: {ex.Message}");
				return false;
			}
		}
		//public async Task<bool> Add(Client client)
		//{
		//	await _context.Clients.AddAsync(client);
		//          await _context.SaveChangesAsync();  
		//	return true;
		//}


		public async Task<Client?> GetById(int id)
		{
			Client? client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
			return client;
		}

		public async Task<bool> Update(Client client)
		{
			try
			{
				// Validate client data here if needed

				_context.Clients.Update(client);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while updating a client: {ex.Message}");
				return false;
			}
		}
		//public async Task<bool> Update(Client client)
		//{
		//	_context.Clients.Update(client);
		//	await _context.SaveChangesAsync();  
		//	return true;
		//}

		//public async Task<bool> Delete(Client client)
		//{

		//              _context.Clients.Remove(client);
		//              await _context.SaveChangesAsync();
		//		return true;

		//}
		public async Task<bool> Delete(Client client)
		{
			try
			{
				// Validate client data here if needed

				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while deleting a client: {ex.Message}");
				return false;
			}
		}


	}
}
