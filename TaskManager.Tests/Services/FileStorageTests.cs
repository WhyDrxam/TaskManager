using Models;
using Services;

namespace TaskManager.Tests.Services.Tests;

public class FileStorageTests
{
    public FileStorageTests()
    {
         fStorage = new FileStorage();
    }

    private FileStorage fStorage;
    //НА СЕЙВ В ДЖСОНЕ
    //тест на входные параметры (путь нулл, путь пустой, файл не джсон, строка не путь)
    //коллекции пустые или нулл(вроде сделал)
    [Theory]
    [InlineData("test.data")]
    public void SaveTasks_PathIsInvalid_ThrowsArgumentExeption(string path)
    {
        //arrange
        List<Job> list = new List<Job>
        {
            new Job(),
            new Job()
        };
        var filePath = Path.Combine(Path.GetTempPath(),path);
        File.Create(filePath);
        
        //act and assert
        Assert.Throws<ArgumentException>(() => fStorage.SaveTasks(list, filePath));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void SaveTasks_PathIsNullOrEmpty_ThrowsArgumentNullExeption(string filePath)
    {
        //Arrange
        List<Job> list = new List<Job>
        {
            new Job(),
            new Job()
        };
        //Act and assert
        Assert.Throws<ArgumentNullException>(() => fStorage.SaveTasks(list, filePath));
    }
    
    [Fact]
    public void SaveTasks_ListIsNull_ThrowsArgumentNullExepction()
    {
        //Arrange
        List<Job> list = null;
        var filePath = Path.Combine(Path.GetTempPath(), "test.json");
        File.Create(filePath);
        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => fStorage.SaveTasks(list, filePath));
    }
    [Fact]
    public void SaveTasks_ListIsEmpty_ThrowsArgumentExepction()
    {
        //Arrange
        List<Job> list = new();
        var filePath = Path.Combine(Path.GetTempPath(), "test.json");
        File.Create(filePath);
        //Act and Assert
        Assert.Throws<ArgumentException>(() => fStorage.SaveTasks(list, filePath));
    }
    
    //НА ЛОАД
    //тест на входные параметры (путь нулл, путь пустой, файл не джсон, строка не путь)
    //
   
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void LoadTasks_PathIsEmpty_ThrowsArgumentNullExepction(string filePath)
    {
        //Arrange
        
        //Act
        
        //Assert
        var ex = Assert.Throws<ArgumentNullException>(() => fStorage.LoadTasks(filePath));
        Assert.Contains(nameof(filePath), ex.Message);
    }

    [Theory]
    [InlineData("abcd")]
    [InlineData(@"Z:\\test.json")]
    public void LoadTasks_PathIsInvalid_ThrowsArgumentExepction(string path)
    {
        var ex = Assert.Throws<ArgumentException>(() => fStorage.LoadTasks(path));

    }

    [Fact]
    public void LoadTasks_FileExtentionIsInvalid_ThrowsArgumentExepction()
    {
        
        var filePath = Path.Combine(Path.GetTempPath(), "test.data");
        File.Create(filePath);
        var ex = Assert.Throws<ArgumentException>(() => fStorage.LoadTasks(filePath));
        Assert.Contains(".data", ex.Message);
        // File.Delete(filePath);
    }
}