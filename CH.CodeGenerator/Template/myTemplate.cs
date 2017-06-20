
@using CH.CodeGenerator
@using System.Net
@using LinqToDB.SchemaProvider
@using LinqToDB.Data;
@using System.Collections.Generic
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using LinqToDB.Mapping;

/* 
Author：@Dns.GetHostName()
DateTime：@DateTime.Now
代码生成器自动生成 RazorEngine3.7.0
*/
 
namespace CH.Model
{  
  @{ 
	 var cols = Model.Table.Columns;
    var tableName = Model.Table.TableName;

}
[Table(Name = "@tableName")]
public class @Helper.ToPascal(tableName)
{
    @foreach(var item in cols)

     {
        if (item.IsPrimaryKey)
        {
        < text >[PrimaryKey] </ text >
		@("\r")

        }
        if (item.IsIdentity)
        {
        < text >[Identity] </ text >
		@("\r")

        }

        < text >[Column(Name = "@item.ColumnName", CanBeNull =@(item.IsNullable ? "false" : "true"))] </ text >
		@("\r")
        < text >public </ text > @item.MemberType<text> </ text > @Helper.ToPascal(item.ColumnName)
          < text >

        {
            get;
            set;
        }

        </ text >
     }
} 
}