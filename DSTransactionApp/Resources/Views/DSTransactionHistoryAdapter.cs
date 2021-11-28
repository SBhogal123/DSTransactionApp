#region namespace
using Android.Content;
using Android.Views;
using Android.Widget;
using DSBusinessServiceLayer.Model;
using System;
using System.Collections.Generic;
#endregion
namespace DSTransactionApp.Resources.Views {
  /// <summary>
  /// This is Adpater class for transaction history activity class
  /// </summary>
  public class DSTransactionHistoryAdapter : BaseAdapter<DSTransactionHistoryModel> {
/// <summary>
/// Global properties
/// </summary>
    Context context;
    List<DSTransactionHistoryModel> transactionhistory=new List<DSTransactionHistoryModel>();
    /// <summary>
    /// DSTransactionHistoryAdapter Method
    /// </summary>
    /// <param name="transactionhistory"></param>
    public DSTransactionHistoryAdapter(List<DSTransactionHistoryModel> transactionhistory) {
      this.transactionhistory = transactionhistory;
    }
    public override int Count {
      get {
        return transactionhistory.Count;
      }
    }
    public override long GetItemId(int position) {
      return position;
    }
    public override View GetView(int position, View convertView, ViewGroup parent) {
      var view = convertView;

      if (view == null) {
        view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DSTransactionHistoryAdapterView, parent, false);

        var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
        var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
        var department = view.FindViewById<TextView>(Resource.Id.departmentTextView);
        var status = view.FindViewById<ImageView>(Resource.Id.status);
        var price = view.FindViewById<TextView>(Resource.Id.price);
        var transfertype = view.FindViewById<TextView>(Resource.Id.transfertype);
        var date = view.FindViewById<TextView>(Resource.Id.date);

        view.Tag = new ViewHolder() { Photo = photo, Name = name, Department = department ,Date=date,Price=price,Status=status,TransferType=transfertype};
      }

      var holder = (ViewHolder)view.Tag;
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

      holder.Name.Text = transactionhistory[position].name;
      holder.Department.Text = transactionhistory[position].bank_name;
      holder.Price.Text = transactionhistory[position].paid_amount.ToString();
      holder.Date.Text = dtDateTime.AddSeconds(transactionhistory[position].createdAt).ToUniversalTime().ToString("yyyy - MM - dd");
      holder.TransferType.Text = transactionhistory[position].transfer_type;
      if (transactionhistory[position].status) {
        holder.Status.SetImageResource(Resource.Drawable.correct);
      } else {
        holder.Status.SetImageResource(Resource.Drawable.wrong);
      }
      return view;    
  }
    public override DSTransactionHistoryModel this[int position] {
      get {
        return transactionhistory[position];
      }
    }
  }
  /// <summary>
  /// View holder class for adapter
  /// </summary>
  public class ViewHolder : Java.Lang.Object {
    public ImageView Photo { get; set; }
    public ImageView Status { get; set; }
    public TextView Name { get; set; }
    public TextView Department { get; set; }
    public TextView TransferType { get; set; }
    public TextView Date { get; set; }
    public TextView Price { get; set; }
  }
}