using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02快速创建图框
{
    public static partial class AddEntityTools
    {
        /// <summary>
        /// 将图形对象添加到图形文件中
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="ent">图形对象</param>
        /// <returns>图形的ObjectId</returns>
        public static ObjectId AddEntityToModeSpace(this Database db, Entity ent)
        {
            // 声明ObjectId 用于返回
            ObjectId entId = ObjectId.Null;
            // 开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // 打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                // 打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                // 添加图形到块表记录
                entId = btr.AppendEntity(ent);
                // 更新数据信息
                trans.AddNewlyCreatedDBObject(ent, true);
                // 提交事务
                trans.Commit();
            }
            return entId;
        }


        /// <summary>
        /// 添加多个图形对象到图形文件中
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="ent">图形对象 可变参数</param>
        /// <returns>图形的ObjectId 数组返回</returns>
        public static ObjectId[] AddEntityToModeSpace(this Database db, params Entity[] ent)
        {
            // 声明ObjectId 用于返回
            ObjectId[] entId = new ObjectId[ent.Length];
            // 开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // 打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                // 打开块表记录
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                for (int i = 0; i < ent.Length; i++)
                {
                    // 将图形添加到块表记录
                    entId[i] = btr.AppendEntity(ent[i]);
                    // 更新数据信息
                    trans.AddNewlyCreatedDBObject(ent[i], true);

                }
                // 提交事务
                trans.Commit();
            }
            return entId;
        }





        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="startPoint">起点坐标</param>
        /// <param name="endPoint">终点坐标</param>
        /// <returns></returns>
        public static ObjectId AddLineToModeSpace(this Database db, Point3d startPoint, Point3d endPoint)
        {
            return db.AddEntityToModeSpace(new Line(startPoint, endPoint));
        }

        /// <summary>
        /// 起点坐标，角度，长度 绘制直线
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="startPoint">起点</param>
        /// <param name="length">长苏</param>
        /// <param name="degree">角度</param>
        /// <returns></returns>
        public static ObjectId AddLineToModeSpace(this Database db, Point3d startPoint, Double length, Double degree)
        {
            // 利用长度和角度以及起点 计算终点坐标
            double X = startPoint.X + length * Math.Cos(degree.DegreeToAngle());
            double Y = startPoint.Y + length * Math.Sin(degree.DegreeToAngle());
            Point3d endPoint = new Point3d(X, Y, 0);
            return db.AddEntityToModeSpace(new Line(startPoint, endPoint));
        }



        // 封装圆弧对象函数
        /// <summary>
        /// 绘制圆弧
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="center">中心</param>
        /// <param name="radius">半径</param>
        /// <param name="startDegree">起始角度</param>
        /// <param name="endDegree">终止角度</param>
        /// <returns></returns>

        public static ObjectId AddArcToModeSpace(this Database db, Point3d center, double radius, double startDegree, double endDegree)
        {
            return db.AddEntityToModeSpace(new Arc(center, radius, startDegree.DegreeToAngle(), endDegree.DegreeToAngle()));
        }


        /// <summary>
        /// 三点画圆弧
        /// </summary>
        /// <param name="db">数据库对象</param>
        /// <param name="startPoint">起点</param>
        /// <param name="pointOnArc">圆弧上一点</param>
        /// <param name="endPoint">终点</param>
        /// <returns></returns>
        public static ObjectId AddArcToModeSpace(this Database db, Point3d startPoint, Point3d pointOnArc, Point3d endPoint)
        {
            // 先判断是否在同一条直线上
            if (startPoint.IsOnOneLine(pointOnArc, endPoint))
            {
                return ObjectId.Null;
            }

            // 创建几何对象
            CircularArc3d cArc = new CircularArc3d(startPoint, pointOnArc, endPoint);

            // 通过几何对象获取其属性
            double radius = cArc.Radius; //半径

            /**************************************
            Point3d center = cArc.Center; // 所在圆的圆心
            Vector3d cs = center.GetVectorTo(startPoint); // 圆心到起点的向量
            Vector3d ce = center.GetVectorTo(endPoint); // 圆心到终点的向量
            Vector3d xVector = new Vector3d(1, 0, 0); // x正方向的向量
            // 圆弧起始角度
            double startAngle = cs.Y > 0 ? xVector.GetAngleTo(cs) : -xVector.GetAngleTo(cs);
            // 圆弧终止角度
            double endAngle = ce.Y > 0 ? xVector.GetAngleTo(ce) : -xVector.GetAngleTo(ce);
            ********************************************/

            // 创建圆弧对象
            Arc arc = new Arc(cArc.Center, cArc.Radius, cArc.Center.GetAngleToXAxis(startPoint), cArc.Center.GetAngleToXAxis(endPoint));
            // 加入到图形数据库
            return db.AddEntityToModeSpace(arc);
        }

        /// <summary>
        /// 绘制圆
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="center">圆心</param>
        /// <param name="radius">半径</param>
        /// <returns></returns>
        public static ObjectId AddCircleModeSpace(this Database db, Point3d center, double radius)
        {
            return db.AddEntityToModeSpace(new Circle((center), new Vector3d(0, 0, 1), radius));
        }

        /// <summary>
        /// 两点绘制圆
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="point1">第一个电</param>
        /// <param name="point2">第二个点</param>
        /// <returns></returns>
        public static ObjectId AddCircleModeSpace(this Database db, Point3d point1, Point3d point2)
        {
            // 获取两点的中心点
            Point3d center = point1.GetCenterPointBetweenTwoPoint(point2);
            // 获取半径
            double radius = point1.GetDistanceBetweenTwoPoint(center);
            return db.AddCircleModeSpace(center, radius);
        }

        /// <summary>
        /// 三点绘制圆
        /// </summary>
        /// <param name="db"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <returns></returns>
        public static ObjectId AddCircleModeSpace(this Database db, Point3d point1, Point3d point2, Point3d point3)

        {
            // 先判断三点是否在同一直线上
            if (point1.IsOnOneLine(point2, point3))
            {
                return ObjectId.Null;
            }
            // 声明几何类Circular3d对象
            CircularArc3d cArc = new CircularArc3d(point1, point2, point3);
            return db.AddCircleModeSpace(cArc.Center, cArc.Radius);
        }


        /// <summary>
        /// 绘制折线多段线
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="isClosed">是否闭合</param>
        /// <param name="contantWidth">线宽</param>
        /// <param name="vertices">多线段的顶点 可变参数</param>
        /// <returns></returns>
        public static ObjectId AddPolyLineToModeSpace(this Database db, bool isClosed, double contantWidth, params Point2d[] vertices)
        {
            if (vertices.Length < 2)  // 顶点个数小于2 无法绘制
            {
                return ObjectId.Null;
            }
            // 声明一个多段线对象
            Polyline pline = new Polyline();
            // 添加多段线顶点
            for (int i = 0; i < vertices.Length; i++)
            {
                pline.AddVertexAt(i, vertices[i], 0, 0, 0);
            }
            if (isClosed)
            {
                pline.Closed = true;
            }
            // 设置多段线的线宽
            pline.ConstantWidth = contantWidth;
            return db.AddEntityToModeSpace(pline);
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="point1">第一个点</param>
        /// <param name="point2">对角点</param>
        /// <returns></returns>
        public static ObjectId AddRectToModeSpace(this Database db, Point2d point1, Point2d point2)
        {
            // 声明多段线
            Polyline pLine = new Polyline();
            // 计算矩形的四个顶点坐标
            Point2d p1 = new Point2d(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2d p2 = new Point2d(Math.Max(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2d p3 = new Point2d(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            Point2d p4 = new Point2d(Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            // 添加多段线顶点
            pLine.AddVertexAt(0, p1, 0, 0, 0); // 参数 索引值 传入点 多段线凸度 起始宽度 终止宽度
            pLine.AddVertexAt(0, p2, 0, 0, 0);
            pLine.AddVertexAt(0, p3, 0, 0, 0);
            pLine.AddVertexAt(0, p4, 0, 0, 0);
            pLine.Closed = true; // 闭合
            return db.AddEntityToModeSpace(pLine);
        }

        /// <summary>
        /// 绘制正多边形
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="center">多边形所在内接圆圆心</param>
        /// <param name="radius">所在圆半径</param>
        /// <param name="sideNum">边数</param>
        /// <param name="startDegree">起始角度</param>
        /// <returns></returns>
        public static ObjectId AddPolygonToModeSpace(this Database db, Point2d center, double radius, int sideNum, double startDegree)
        {
            // 声明一个多段线对象
            Polyline pLine = new Polyline();
            // 判断边数是否符合要求
            if (sideNum < 3)
            {
                return ObjectId.Null;
            }
            Point2d[] point = new Point2d[sideNum]; // 有几条边就有几个点
            double angle = startDegree.DegreeToAngle();
            // 计算每个顶点坐标
            for (int i = 0; i < sideNum; i++)
            {
                point[i] = new Point2d(center.X + radius * Math.Cos(angle), center.Y + radius * Math.Sin(angle));
                pLine.AddVertexAt(i, point[i], 0, 0, 0);
                angle += Math.PI * 2 / sideNum;
            }
            // 闭合多段线
            pLine.Closed = true;
            return db.AddEntityToModeSpace(pLine);
        }
        /// <summary>
        /// 绘制椭圆
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="center">椭圆中心</param>
        /// <param name="majorRadius">长轴长度</param>
        /// <param name="shortRadius">短轴长度</param>
        /// <param name="degree">长轴与X夹角 角度值</param>
        /// <param name="startDegree">起始角度</param>
        /// <param name="endDegree">终止角度</param>
        /// <returns></returns>
        public static ObjectId AddEllipseToModeSpace(this Database db, Point3d center, double majorRadius, double shortRadius, double degree, double startDegree, double endDegree)
        {
            // 计算相关参数
            double ratio = shortRadius / majorRadius;
            Vector3d majorAxis = new Vector3d(majorRadius * Math.Cos(degree.AngleToDegree()), majorRadius * Math.Sin(degree.DegreeToAngle()), 0);
            Ellipse elli = new Ellipse(center, Vector3d.ZAxis, majorAxis, ratio, startDegree.DegreeToAngle(), endDegree.DegreeToAngle()); // VVector3d.ZAxis 等价于 new Vector3d(0,0,1) 平行于z轴法向量
            return db.AddEntityToModeSpace(elli);
        }


        /// <summary>
        /// 三点绘制椭圆
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="majorPoint1">长轴端点1</param>
        /// <param name="majorPoint2">长轴端点2</param>
        /// <param name="shortRadius">短轴的长度</param>
        /// <returns>ObjectId</returns>
        public static ObjectId AddEllipseToModeSpace(this Database db, Point3d majorPoint1, Point3d majorPoint2, double shortRadius)
        {
            // 椭圆圆心
            Point3d center = majorPoint1.GetCenterPointBetweenTwoPoint(majorPoint2);
            // 短轴与长轴的比例
            double ratio = 2 * shortRadius / majorPoint1.GetDistanceBetweenTwoPoint(majorPoint2);
            // 长轴的向量
            Vector3d majorAxis = majorPoint2.GetVectorTo(center);
            Ellipse elli = new Ellipse(center, Vector3d.ZAxis, majorAxis, ratio, 0, 2 * Math.PI);
            return db.AddEntityToModeSpace(elli);
        }

        /// <summary>
        /// 绘制椭圆 两点
        /// </summary>
        /// <param name="db"></param>
        /// <param name="point1">所在矩形的顶点</param>
        /// <param name="point2">所在矩形的顶点2</param>
        /// <returns></returns>
        public static ObjectId AddEllipseToModeSpace(this Database db, Point3d point1, Point3d point2)
        {
            // 椭圆圆心
            Point3d center = point1.GetCenterPointBetweenTwoPoint(point2);

            double ratio = Math.Abs((point1.Y - point2.Y) / (point1.X - point2.X));
            Vector3d majorVector = new Vector3d(Math.Abs((point1.X - point2.X)) / 2, 0, 0);
            // 声明椭圆对象
            Ellipse elli = new Ellipse(center, Vector3d.ZAxis, majorVector, ratio, 0, 2 * Math.PI);
            return db.AddEntityToModeSpace(elli);
        }
    }
}
