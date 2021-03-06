﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.ConventionalChangelog;
using NUnit.Framework;
using System.IO;

namespace Cake.ConventionalChangelog.Tests
{
    [TestFixture]
    public class EmptyRepoTests
    {
        private Git git;

        [SetUp]
        public void Setup()
        {
            Util.InitEmptyRepo();

            git = new Git(Util.GetFullPath(Util.EMPTY_REPO_DIR));
        }

        [TearDown]
        public void TearDown()
        {
            Util.CleanupRepos();
        }

        [Test]
        public void GetFirstCommit_NoCommitsThrowsError()
        {
            GitException ex = Assert.Throws<GitException>(() =>
            {
                git.GetFirstCommit();
            });

            Assert.True(ex.Message.ToLower().Contains("no commits found"));
        }

        [Test]
        public void LatestTag_WithNoCommitsThrows()
        {
            Assert.Throws<GitException>(() =>
            {
                git.LatestTag();
            });
        }
    }
}
