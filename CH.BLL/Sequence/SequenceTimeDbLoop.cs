using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH.Model;
using LinqToDB;
using DataAccess;
using DataAccess.Domain.Uow;
using LinqToDB.Mapping;
using LinqToDB.Data;
namespace CH.BLL.Sequence
{

    public enum FormatType
    {

        Date = 0,

        Normal = 1

    }


    public class SysSequenceEx : SysSequence
    {

        [NotColumn]
        public DateTime SysDate { get; set; }
    }


    /// <summary>
    /// 时间循环
    /// </summary>
    public class SequenceTimeDbLoop : ISequence
    {
        public string SeqId { get; set; }

        private SysSequenceEx Seq = null;
        public SequenceTimeDbLoop()
        {

        }


        private object UpdateValue(LinqToDB.Data.DataConnection db)
        {

            if (string.IsNullOrEmpty(Seq.CFormatType)) throw new Exception("FormatType is null");
            if ((FormatType)Convert.ToInt32(Seq.CFormatType) == FormatType.Date)
            {

                //如果 
                if (string.IsNullOrEmpty(Seq.CCurdate))
                {

                    
                    Seq.CCurval = "0";

                    //加
                    Seq.CCurval = $"{Convert.ToDouble(string.IsNullOrEmpty(Seq.CCurval) ? "0" : Seq.CCurval) + Convert.ToDouble(Seq.NStep)}";
                }

                else
                {
                    //如果日期不相等 重置
                    if (Seq.CCurdate != Seq.SysDate.ToString(Seq.CFormat))
                    {
                        Seq.CCurval = "0";

                    }
                    Seq.CCurval = $"{Convert.ToDouble(string.IsNullOrEmpty(Seq.CCurval) ? "0" : Seq.CCurval) + Convert.ToDouble(Seq.NStep)}";
                }
                //设置日期
                Seq.CCurdate = Seq.SysDate.ToString(Seq.CFormat);

                Seq.CVal = $"{Seq.CPrechar}{Seq.SysDate.ToString(Seq.CFormat)}{Seq.CCurval.PadLeft((int)Seq.CPadlen, Seq.CPadchar.ToCharArray()[0])}";

            }
            else
            {
                Seq.CCurval = $"{Convert.ToDouble(string.IsNullOrEmpty(Seq.CCurval) ? "0" : Seq.CCurval) + Convert.ToDouble(Seq.NStep)}";

                Seq.CVal = $"{Seq.CPrechar}{Seq.CCurval.PadLeft((int)Seq.CPadlen, Seq.CPadchar.ToCharArray()[0])}";
            }

            var trans = db.BeginTransaction();
            try
            {

                int i = db.Query<SysSequence>().Where(m => m.CVersion == Seq.CVersion && m.SeqId == Seq.SeqId).Update(m => new SysSequence() { CVersion = m.CVersion + 1, CCurdate = Seq.CCurdate, CCurval = Seq.CCurval, CVal = Seq.CVal });
                //int i=  db.Query<SysSequence>().Where(m => m.CTimestamp == Seq.CTimestamp&&m.SeqId==Seq.SeqId).Update(m=>new SysSequence() { CTimestamp=Sql.ToSql(Sql.CurrentTimestamp), CCurdate=Seq.CCurdate, CCurval=Seq.CCurval, CVal=Seq.CVal });
                if (i > 0)
                {
                    trans.Commit();
                }
                else
                    Seq.CVal = string.Empty;
            }
            catch
            {
                trans.Rollback();
            }

            finally
            {
                trans.Dispose();
            }
            return Seq.CVal;
        }

            public object Next(string SeqId)
        {
            this.SeqId = SeqId;
            using (var db = Linq2DbConnectionManager.Get())
            {
                var rs = db.Query<SysSequence>().Where(m => m.SeqId == SeqId).Select(m => new SysSequenceEx()
                { 
                    SeqId = m.SeqId,
                    CCurdate = m.CCurdate,
                    CCurval = m.CCurval,
                    CFormat = m.CFormat,
                    CFormatType = m.CFormatType,
                    CPadchar = m.CPadchar,
                    CPadlen = m.CPadlen,
                    CPrechar = m.CPrechar,
                    CVal = m.CVal,
                    NStep = m.NStep, 
                    SysDate = Sql.AsSql(Sql.CurrentTimestamp),
                    CVersion = m.CVersion

                }).ToList();

              Seq = rs.FirstOrDefault();

            if (Seq == null) throw new Exception("SeqId is not exits in Sequence");

            object val = UpdateValue(db);
                return val;
            }
          
            //获取当前类名

            //更新值 

           
        }
    }
}
