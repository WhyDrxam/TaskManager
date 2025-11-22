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
    //коллекции пустые или нулл
    
    
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