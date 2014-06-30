﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tatan.Common.IO;
using Tatan.Data;
using Tatan.Common.Serialization;
using Tatan.Common.Configuration;
using Tatan.Data.Generator;
using Tatan.Data.Relation;


namespace Tatan.Data.UnitTest
{
    using Tatan.Common.Cryptography;

    [TestClass]
    public class SqliteGeneratorTest
    {
        private IDataSource _source;

        [TestInitialize]
        public void Init()
        {
            if (System.IO.File.Exists(Runtime.Root + "Table1.sql"))
                System.IO.File.Delete(Runtime.Root + "Table1.sql");
            string p = "System.Data.SQLite";
            string c = @"Data Source=Db\test.db3;Version=3;";
            _source = DataSource.Connect(p, c);
            _source.Tables.Add(typeof(Tatan.Data.Relation.Fields));
            _source.Tables.Add(typeof(Tatan.Data.Relation.Tables));
        }

        [TestMethod]
        public void TestExecute()
        {
            var st = new List<Tables>
            {
                new Tables(1)
                {
                    Name = "Table1",
                    Title = "表1"
                }
            };
            var f = new Fields
            {
                Name = "col1",
                Title = "字段1",
                DefaultValue = string.Empty,
                OrderId = 0,
                Size = 10,
                Type = "S",
                IsNotNull = true,
                TableId = 1
            };
            _source.Tables["Fields"].Insert(f);
            IGenerator g = new SqliteGenerator(st, _source);
            g.Execute(Runtime.Root);
            var s = _source.Tables["Fields"].Delete<Fields>(field => field.Name == "col1");
        }

        [TestMethod]
        public void TestExecuteTableNull()
        {
            IGenerator g = new SqliteGenerator(null, _source);
            g.Execute(Runtime.Root);
        }

        [TestMethod]
        public void TestExecuteTableNull2()
        {
            IGenerator g = new SqliteGenerator(null, _source);
            g.Execute(Runtime.Root.Substring(0, Runtime.Root.Length - 1));
        }

        [TestMethod]
        public void TestExecuteSourceNull()
        {
            var st = new List<Tables>
            {
                new Tables(1)
                {
                    Name = "Table1",
                    Title = "表1"
                }
            };
            IGenerator g = new SqliteGenerator(st, null);
            try
            {
                g.Execute(Runtime.Root);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}
    