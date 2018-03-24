﻿#region	License
//--------------------------------------------------
// <License>
//     <Copyright> 2018 © Top Nguyen </Copyright>
//     <Url> http://topnguyen.net/ </Url>
//     <Author> Top </Author>
//     <Project> Elect </Project>
//     <File>
//         <Name> DataTableResponseDataModel.cs </Name>
//         <Created> 23/03/2018 5:44:23 PM </Created>
//         <Key> c971bcc4-c79b-4ea0-a2a4-3f399c9b6962 </Key>
//     </File>
//     <Summary>
//         DataTableResponseDataModel.cs is a part of Elect
//     </Summary>
// <License>
//--------------------------------------------------
#endregion License

using Elect.Web.DataTable.Models.Constants;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Elect.Web.DataTable.Models.Response
{
    public class DataTableResponseDataModel<T> where T : class, new()
    {
        [JsonProperty(PropertyName = PropertyConstants.TotalRecords)]
        public int TotalRecord { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.TotalDisplayRecords)]
        public int TotalDisplayRecord { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.Echo)]
        public int Echo { get; set; }

        [JsonProperty(PropertyName = PropertyConstants.Data)]
        public object[] Data { get; set; }

        public Type DataType { get; } = typeof(T);

        public DataTableResponseDataModel<T> Transform<TData, TTransform>(Func<TData, TTransform> transformRow, ResponseOptionModel responseOptions = null)
        {
            var data = new DataTableResponseDataModel<T>
            {
                Data = Data.Cast<TData>().Select(transformRow).Cast<object>().ToArray(),
                TotalDisplayRecord = TotalDisplayRecord,
                TotalRecord = TotalRecord,
                Echo = Echo
            };
            return data;
        }
    }
}