#region namespace
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DSBusinessServiceLayer.Model;
#endregion
namespace DSBusinessServiceLayer {
  /// <summary>
  /// DSTransactionHistoryService: This is the service class for the transaction history 
  /// </summary>
  public class DSTransactionHistoryService {
    /// <summary>
    /// Public properties
    /// </summary>
   public List<DSTransactionHistoryModel> dSTransactionHistorylist = new List<DSTransactionHistoryModel>();
    /// <summary>
    /// GetTransactionHIstory: This is the transaction history method to get the history of transactions
    /// </summary>
    /// <returns></returns>
    public async Task<List<DSTransactionHistoryModel>> GetTransactionHIstory() {
      try {
        using (var client = new HttpClient()) {
          // send a GET request  
          var uri = "http://61769aed03178d00173dad89.mockapi.io/api/v1/transactions";
          var result = await client.GetStringAsync(uri);
          var transactionhistory = JsonConvert.DeserializeObject<List<DSTransactionHistoryModel>>(result);
          return transactionhistory;
        }       
      } catch (Exception ex) {
        Console.Write(ex.InnerException);
        return null;
      }
    }
  }
  }
