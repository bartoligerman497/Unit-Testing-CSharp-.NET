using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Runtime.ConstrainedExecution;

namespace StringManipulation.Tests
{
    public class StringOperationTest
    {
        [Fact]
        public void ConcatenateStrings()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }

        // dotnet test

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();

            var result = strOperations.RemoveWhitespace("German Bartoli  .");

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("GermanBartoli.", result);
        }

        [Fact]
        public void QuantityInWords()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            // Assert
            Assert.StartsWith("diez", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength()
        {
            //Arrange
            var strStringManipulation = new StringOperations();
            //Act 
            var word = "New word";
            var result = strStringManipulation.GetStringLength(word);
            //Assert
            Assert.Equal(word.Length, result);
        }

        [Fact]
        public void GetstringLength_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }


        [Fact]
        public void TruncateString_Exception()
        {
            //Arrange
            var strStringManipulation = new StringOperations();
            //Act //Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strStringManipulation.TruncateString("Test", 0));
        }

        // Atributos Theory e InlineData 9/19
        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        //[InlineData("p", -1)]
        public void FromRomanToNumber(string romanNumber, int expected) {
            //Arrange
            var srtOperations = new StringOperations();

            var result = srtOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        // Atributo Skip 10/19
        [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-000")]
        public void ConcatenateStrings2()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        // Utilizando la libreria Moq 13/19

        [Fact]
        public void CountOccurences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();

            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
        }

        //Mock de funciones 14/19
        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            //mockFileReader.Setup(p=> p.ReadString("file.txt")).Returns("Reading file");
            mockFileReader.Setup(p=> p.ReadString(It.IsAny<string>())).Returns("Reading file");

            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);
        }

        // Iniciando con Coverlet 16/19
        // dotnet add package coverlet.msbuild
        // dotnet add package coverlet.collector
        // dotnet test /p:CollectCoverage= true

        // Atributos de configuración en coverlet 17/19
        // dotnet test /p:CollectCoverage=true /p:ExcludeByAttribute="ExcludeFromCodeCoverage" 
        // dotnet test /p:CollectCoverage=true /p:Include="[*]StringManipulation.*"

        // Reporte de cobertura 18/19
        // No funcionó, lo hacia con json
        // Parámetro para crear un reporte de la cobertura de los test con Coverlet:
        // dotnet test /p:CollectCoverage=true /p:CoverletOutpuFormat=cobertura

        // Funcionó con chat GPT
        // dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
        // reportgenerator "-reports:coverage-report/coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:Html
        
        // reportgenerator "-reports:coverage.opencover.xml" "-targetdir:coverage-report" -reporttypes:Html

        /*
        dotnet tool install -g dotnet-reportgenerator-globaltool

        dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools

        dotnet new tool-manifest
        dotnet tool install dotnet-reportgenerator-globaltool
         */

        // reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:html;

        // extendión fine code coverage
    }
}
