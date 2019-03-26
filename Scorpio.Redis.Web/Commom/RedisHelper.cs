﻿using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scorpio.Redis.Web.Commom
{
    public class RedisHelper
    {
        #region static field

        static string host = "192.168.2.154";/*访问host地址*/
        static string password = "2016@Msd.1127_kjy";/*实例id:密码*/
        static readonly RedisClient client = new RedisClient(host, 6379, password);

        #endregion
        #region
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象</returns>
        public static T Get<T>(string token) where T : class, new()
        {
            return client.Get<T>(token);
        }
        /// <summary>
        /// 设置信息
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="token">key</param>
        /// <param name="obj">对象</param>
        public static void Set<T>(string token, T obj) where T : class, new()
        {
            client.Set<T>(token, obj);
        }
        /// <summary>
        /// 设置指定Key的过期时间
        /// </summary>
        /// <param name="token">具体的key值</param>
        /// <param name="seconds">过期时间，单位：秒</param>
        public static void Expire(string token, int seconds)
        {
            client.Expire(token, seconds);
        }
        #endregion
    }
}