namespace DSBusinessServiceLayer.Model {
  /// <summary>
  /// DSTransactionHistoryModel: This is the model class for Transaction app
  /// </summary>
  public class DSTransactionHistoryModel {
      public int createdAt { get; set; }
      public string name { get; set; }
      public string bank_name { get; set; }
      public string transfer_type { get; set; }
      public int receiving_amount { get; set; }
      public bool status { get; set; }
      public string reference_number { get; set; }
      public string cf_number { get; set; }
      public string payout_location { get; set; }
      public string account_number { get; set; }
      public int paid_amount { get; set; }
      public string id { get; set; }
    }
  }

