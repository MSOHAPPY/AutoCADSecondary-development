using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02快速创建图框
{
    public class TextTool
    {

        /// <summary>
        /// 初始化文字样式
        /// </summary>
        /// <param name="StyleName">文字样式名称</param>
        /// <param name="FontName">字体名称</param>
        /// <param name="WidthFactor">宽度因子</param>
        /// <param name="charset">字符集，中文3212默认134</param>
        /// <param name="pf">字族，</param>
        public void InitTextStyle(string StyleName, string FontName, double WidthFactor, int charset = 134, int pf = 48)
        {
            Database acCurDb = HostApplicationServices.WorkingDatabase;
            using (Transaction tr = acCurDb.TransactionManager.StartTransaction())
            {
                TextStyleTable st = tr.GetObject(acCurDb.TextStyleTableId, OpenMode.ForWrite) as TextStyleTable;


                #region 字体设置
                if (!st.Has(StyleName))//字体设置
                {
                    TextStyleTableRecord str = new TextStyleTableRecord()
                    {
                        Name = StyleName,
                        Font = new Autodesk.AutoCAD.GraphicsInterface.FontDescriptor(FontName, false, false, charset, pf),
                        XScale = WidthFactor,
                    };
                    st.Add(str);
                    tr.AddNewlyCreatedDBObject(str, true);
                }
                else
                {
                    TextStyleTableRecord str = tr.GetObject(st[StyleName], OpenMode.ForWrite) as TextStyleTableRecord;
                    str.Font = new Autodesk.AutoCAD.GraphicsInterface.FontDescriptor(FontName, false, false, charset, pf);
                    str.XScale = WidthFactor;
                }
                #endregion
                tr.Commit();
            }
        }


    }
}
