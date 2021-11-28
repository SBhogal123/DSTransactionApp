#region namespace
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DSBusinessServiceLayer.Model;
using DSBusinessServiceLayer.ViewModel;
using System;
using System.Threading.Tasks;
#endregion
namespace DSTransactionApp.Resources.Views {
  /// <summary>
  /// DSTransactionDetailsView: This is transaction detail activity class
  /// </summary>
  [Activity(Label = "DSTransactionDetailsView")]
  public class DSTransactionDetailsView : Activity {
    /// <summary>
    /// OnCreate Method
    /// </summary>
    /// <param name="savedInstanceState"></param>
    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.DSTransactionDetiailsView);
      string id = Intent.GetStringExtra("Transactionid");
      GetDetails(id);
      FindViewById<Button>(Resource.Id.backbutton).Click += DSTransactionDetailsView_Click;
    }
    /// <summary>
    ///DSTransactionDetailsView_Click : Back Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DSTransactionDetailsView_Click(object sender, EventArgs e) {
      this.Finish();    }
    /// <summary>
    /// GetDetails: This is the get details method based upon the id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> GetDetails(string id) {
      DSTransactionDetailsService dSTransactionDetailsService = new DSTransactionDetailsService();
      DSTransactionHistoryModel details= await dSTransactionDetailsService.GetTransactionDetails(id);
      FindViewById<TextView>(Resource.Id.transactionrefnumber).Text=details.reference_number;
      FindViewById<TextView>(Resource.Id.cfnumber).Text = details.cf_number;
      FindViewById<TextView>(Resource.Id.beneficaryname).Text = details.name;
      FindViewById<TextView>(Resource.Id.beneficiarybankname).Text = details.bank_name;
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      if (details.status) {
        FindViewById<ImageView>(Resource.Id.photoImageView).SetImageResource(Resource.Drawable.correct);
        FindViewById<TextView>(Resource.Id.successtitle).Text = "Success";
      } else {
        FindViewById<ImageView>(Resource.Id.photoImageView).SetImageResource(Resource.Drawable.wrong);
        FindViewById<TextView>(Resource.Id.successtitle).Text = "Failed";
      }
      FindViewById<TextView>(Resource.Id.payoutlocation).Text = details.payout_location;
      FindViewById<TextView>(Resource.Id.Accountnumer).Text = details.account_number;
      FindViewById<TextView>(Resource.Id.paymentdate).Text = dtDateTime.AddSeconds(details.createdAt).ToUniversalTime().ToString("yyyy - MM - dd");
      FindViewById<TextView>(Resource.Id.pricetitle).Text = details.receiving_amount.ToString();
      FindViewById<TextView>(Resource.Id.paidamount).Text = details.paid_amount.ToString();
      return true;
    }
  }
}