using Android.App;
using Android.Content;
using Android.OS;
#region namespace
using Android.Widget;
using DSBusinessServiceLayer;
using DSBusinessServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion
namespace DSTransactionApp.Resources.Views {
  /// <summary>
  /// Transaction history activity class
  /// </summary>
  [Activity(Label = "Transaction History")]
  public class DSTransactionHistoryView:Activity {
    #region global properties
    public string[] Items;
    public ListView Transactionhistoylist;
    #endregion

    /// <summary>
    /// OnCreate method
    /// </summary>
    /// <param name="bundle"></param>
    protected  override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      // Set our view from the "main" layout resource  
      SetContentView(Resource.Layout.DSTransactionHistoryView);
      Transactionhistoylist = (ListView)FindViewById<ListView>(Resource.Id.transactionlistview);
      GetData();     
    }
    /// <summary>
    /// Get Data method for getting transaction history
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetData() {
      try {
        DSTransactionHistoryService dSTransactionHistoryService = new DSTransactionHistoryService();
        List<DSTransactionHistoryModel> list = await dSTransactionHistoryService.GetTransactionHIstory();
        Transactionhistoylist.Adapter = new DSTransactionHistoryAdapter(list);
        dSTransactionHistoryService.dSTransactionHistorylist = list;
        Transactionhistoylist.ItemClick += async(s, e) => {        
          var t = dSTransactionHistoryService.dSTransactionHistorylist[e.Position];
          Intent intent = new Intent(this, typeof(DSTransactionDetailsView));
          intent.PutExtra("Transactionid", t.id);
          StartActivity(intent);          
        };
        return true;
      } catch (Exception ex) {
        return false;
      }
    }
    
  }
}