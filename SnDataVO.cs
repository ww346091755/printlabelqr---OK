using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace printlabelqr
{
    class SnDataVO
    {
        #region 成员变量、构造函数
        string m_strTableName;
        string m_SERIAL_NO;
        string m_EP_NO;
        string m_LOT_NO;
        string m_PROD_DATE;
        string m_WO_NO;
        string m_QTY;
        string m_UNIT;
        string m_SUPPLYER_ID;
        string m_SUPPLYER;
        string m_PART_NO;
        string m_PART_NAME;
        string m_BAND;
        string m_SPEC;
        string m_MATERIAL;
        string m_BUY_NO;
        string m_BUY_ENTRY;
        string m_VERIFIER;
        string m_REMARK;
        DateTime m_UPDATE_TIME;

        /// <summary>
        /// 初始化类 SnDataVO 的新实例。
        /// </summary>
        public SnDataVO()
        {
            m_strTableName = "sn_data";
        }
        #endregion

        #region 字段属性
        /// <summary>
        /// 获取实体类对应的数据库表名。
        /// </summary>
        public string TableName
        {
            get
            {
                return m_strTableName;
            }
        }



        /// <summary>
        /// 流水号
        /// </summary>
        public string SERIAL_NO
        {
            get
            {
                return m_SERIAL_NO;
            }
            set
            {
                m_SERIAL_NO = value;
            }
        }

        /// <summary>
        /// 电镀批号
        /// </summary>
        public string EP_NO
        {
            get
            {
                return m_EP_NO;
            }
            set
            {
                m_EP_NO = value;
            }
        }

        /// <summary>
        /// 制造批号
        /// </summary>
        public string LOT_NO
        {
            get
            {
                return m_LOT_NO;
            }
            set
            {
                m_LOT_NO = value;
            }
        }

        /// <summary>
        /// 制造日期
        /// </summary>
        public string PROD_DATE
        {
            get
            {
                return m_PROD_DATE;
            }
            set
            {
                m_PROD_DATE = value;
            }
        }

        /// <summary>
        /// 工单
        /// </summary>
        public string WO_NO
        {
            get
            {
                return m_WO_NO;
            }
            set
            {
                m_WO_NO = value;
            }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public string QTY
        {
            get
            {
                return m_QTY;
            }
            set
            {
                m_QTY = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT
        {
            get
            {
                return m_UNIT;
            }
            set
            {
                m_UNIT = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SUPPLYER_ID
        {
            get
            {
                return m_SUPPLYER_ID;
            }
            set
            {
                m_SUPPLYER_ID = value;
            }
        }

        /// <summary>
        /// 供应商
        /// </summary>
        public string SUPPLYER
        {
            get
            {
                return m_SUPPLYER;
            }
            set
            {
                m_SUPPLYER = value;
            }
        }

        /// <summary>
        /// 料号
        /// </summary>
        public string PART_NO
        {
            get
            {
                return m_PART_NO;
            }
            set
            {
                m_PART_NO = value;
            }
        }

        /// <summary>
        /// 品名
        /// </summary>
        public string PART_NAME
        {
            get
            {
                return m_PART_NAME;
            }
            set
            {
                m_PART_NAME = value;
            }
        }

        /// <summary>
        /// 带别
        /// </summary>
        public string BAND
        {
            get
            {
                return m_BAND;
            }
            set
            {
                m_BAND = value;
            }
        }

        /// <summary>
        /// 规格
        /// </summary>
        public string SPEC
        {
            get
            {
                return m_SPEC;
            }
            set
            {
                m_SPEC = value;
            }
        }

        /// <summary>
        /// 材质
        /// </summary>
        public string MATERIAL
        {
            get
            {
                return m_MATERIAL;
            }
            set
            {
                m_MATERIAL = value;
            }
        }

        /// <summary>
        /// 采购单号
        /// </summary>
        public string BUY_NO
        {
            get
            {
                return m_BUY_NO;
            }
            set
            {
                m_BUY_NO = value;
            }
        }

        /// <summary>
        /// 采购项次
        /// </summary>
        public string BUY_ENTRY
        {
            get
            {
                return m_BUY_ENTRY;
            }
            set
            {
                m_BUY_ENTRY = value;
            }
        }

        /// <summary>
        /// 检验员
        /// </summary>
        public string VERIFIER
        {
            get
            {
                return m_VERIFIER;
            }
            set
            {
                m_VERIFIER = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            get
            {
                return m_REMARK;
            }
            set
            {
                m_REMARK = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UPDATE_TIME
        {
            get
            {
                return m_UPDATE_TIME;
            }
            set
            {
                m_UPDATE_TIME = value;
            }
        }

        #endregion
    }
}
