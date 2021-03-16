using System.Data;

namespace AutoUpdate
{

    partial class UpdateListDataSet
    {

        public void MakeTable()
        {

            DataTable table = new DataTable("UpdateListDataTabale");

            DataColumn column = new DataColumn();

            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "FileName";

            table.Columns.Add(column);

            DataColumn modifiedDate = new DataColumn();
            DataColumn comment = new DataColumn();
            DataColumn version = new DataColumn();
        }


    }
}
