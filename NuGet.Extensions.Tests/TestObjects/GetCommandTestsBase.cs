﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using NuGet.Common;
using NuGet.Extensions.Commands;
using NuGet.Extras.Tests.TestObjects;
using MockFileSystem = NuGet.Extensions.Tests.Mocks.MockFileSystem;
using MockPackageRepository = NuGet.Extensions.Tests.Mocks.MockPackageRepository;

namespace NuGet.Extensions.Tests.TestObjects
{
    public abstract class GetCommandTestsBase
    {
        protected Get GetCommand;
        protected Mock<MockFileSystem> FileSystem;
        protected Mock<MockPackageRepository> CacheRepository;

        [SetUp]
        public void SetUp()
        {
            FileSystem = Utilities.CreatePopulatedMockFileSystem();
            FileSystem.Setup(f => f.Root).Returns(@"c:\TestSolution");
            CacheRepository = new Mock<MockPackageRepository>() { CallBase = true };
            GetCommand = new TestGetCommand(Utilities.GetFactory(), Utilities.GetSourceProvider(), CacheRepository.Object, FileSystem);
            GetCommand.Console = new Mock<IConsole>().Object;
            SetUpTest();         
        }

        protected abstract void SetUpTest();

        [Test]
        public void CommandIsNotNull()
        {
            Assert.IsNotNull(GetCommand);
        }
    }
}