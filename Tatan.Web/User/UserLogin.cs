﻿namespace Tatan.Web.User
{
    using System;
    using Common.Collections;
    using Data;

    /// <summary>
    /// 用户登录信息
    /// </summary>
    [Serializable]
    public partial class UserLogin : DataEntity
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserLogin()
            : base(string.Empty)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">唯一标识符</param>
        public UserLogin(string id)
            : base(id)
        {
        }
        #endregion

        #region Static Properties
        [NonSerialized]
        private static readonly PropertyCollection _perproties;

        static UserLogin()
        {
            _perproties = new PropertyCollection(typeof(UserLogin),
                "Name", "Password", "RegisterTime", "Count", "LastLoginTime", "LastLogoutTime", "LastLoginIp"
            );
        }
        #endregion

        #region Override Methods
        /// <summary>
        /// 获取属性集合
        /// </summary>
        protected override PropertyCollection Properties
        {
            get { return _perproties; }
        }

        /// <summary>
        /// 清理属性
        /// </summary>
        public override void Clear()
        {
            Name = default(string);
            Password = default(string);
            RegisterTime = default(DateTime);
            Count = default(int);
            LastLoginTime = default(DateTime);
            LastLogoutTime = default(DateTime);
            LastLoginIp = default(string);
        }
        #endregion

        #region Properties

        /// <summary>
        /// 登录名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 登陆次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后一次登出时间
        /// </summary>
        public DateTime LastLogoutTime { get; set; }
                
        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public string LastLoginIp { get; set; }

        #endregion
    }
}