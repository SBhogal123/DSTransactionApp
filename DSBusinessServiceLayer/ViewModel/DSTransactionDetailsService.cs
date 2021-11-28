#region namespace
using DSBusinessServiceLayer.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
#endregion
namespace DSBusinessServiceLayer.ViewModel {
  /// <summary>
  /// DSTransactionDetailsService: This is the Service class for Transaction Details
  /// </summary>
  public class DSTransactionDetailsService {
    /// <summary>
    /// GetTransactionDetails: This method will get the details based on the transaction id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DSTransactionHistoryModel> GetTransactionDetails(string id) {
      try {
        using (var client = new HttpClient()) {
          // send a GET request  
          var uri = "http://61769aed03178d00173dad89.mockapi.io/api/v1/transactions/"+id;
          var result = await client.GetStringAsync(uri);
          var transactionhistory = JsonConvert.DeserializeObject<DSTransactionHistoryModel>(result);
          return transactionhistory;
        }
      } catch (Exception ex) {
        Console.Write(ex.InnerException);
        return null;
      }
    }
  }
}
