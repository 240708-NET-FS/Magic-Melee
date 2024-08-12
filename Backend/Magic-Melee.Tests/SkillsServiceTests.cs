using MagicMelee.Services;
using MagicMelee.Data;
using MagicMelee.Models;
using MagicMelee.DTO;
using MagicMelee.Utilities;
using MagicMelee.Exceptions;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MagicMelee.Tests;

public class SkillsServiceTests
{
    private readonly Mock<ISkillsRepo> _skillsRepoMock;
    private readonly Mock<ILogger<SkillsService>> _loggerMock;
    private readonly SkillsService _skillsService;

    public SkillsServiceTests()
    {
        _skillsRepoMock = new Mock<ISkillsRepo>();
        _loggerMock = new Mock<ILogger<SkillsService>>();
        _skillsService = new SkillsService(_skillsRepoMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnSkillsDTO_WhenSkillsExist()
    {
        // Arrange
        var skills = new Skills { SkillsId = 1, Athletics = 5 };
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(skills);

        // Act
        var result = await _skillsService.GetByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.SkillsId);
        Assert.Equal(5, result.Athletics);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowMagicMeleeException_WhenSkillsDoNotExist()
    {
        // Arrange
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Skills)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _skillsService.GetByIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfSkillsDTOs()
    {
        // Arrange
        var skillsList = new List<Skills>
        {
            new Skills { SkillsId = 1, Athletics = 5 },
            new Skills { SkillsId = 2, Acrobatics = 7 }
        };
        _skillsRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(skillsList);

        // Act
        var result = await _skillsService.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task AddAsync_ShouldAddSkillsSuccessfully()
    {
        // Arrange
        var skillsDto = new SkillsDTO { SkillsId = 1, Athletics = 5 };

        // Act
        await _skillsService.AddAsync(skillsDto);

        // Assert
        _skillsRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Skills>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateSkillsSuccessfully()
    {
        // Arrange
        var existingSkills = new Skills { SkillsId = 1, Athletics = 5 };
        var updatedSkillsDto = new SkillsDTO { SkillsId = 1, Athletics = 10 };
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingSkills);

        // Act
        await _skillsService.UpdateAsync(updatedSkillsDto);

        // Assert
        _skillsRepoMock.Verify(repo => repo.UpdateAsync(It.IsAny<Skills>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowMagicMeleeException_WhenSkillsDoNotExist()
    {
        // Arrange
        var skillsDto = new SkillsDTO { SkillsId = 1, Athletics = 10 };
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Skills)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _skillsService.UpdateAsync(skillsDto));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteSkillsSuccessfully()
    {
        // Arrange
        var skills = new Skills { SkillsId = 1, Athletics = 5 };
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(skills);

        // Act
        await _skillsService.DeleteAsync(1);

        // Assert
        _skillsRepoMock.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrowMagicMeleeException_WhenSkillsDoNotExist()
    {
        // Arrange
        _skillsRepoMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Skills)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _skillsService.DeleteAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldReturnSkillsDTO_WhenSkillsExistForCharacter()
    {
        // Arrange
        var skills = new Skills { SkillsId = 1, Athletics = 5 };
        _skillsRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync(skills);

        // Act
        var result = await _skillsService.GetByCharacterIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.SkillsId);
        Assert.Equal(5, result.Athletics);
    }

    [Fact]
    public async Task GetByCharacterIdAsync_ShouldThrowMagicMeleeException_WhenSkillsDoNotExistForCharacter()
    {
        // Arrange
        _skillsRepoMock.Setup(repo => repo.GetByCharacterIdAsync(1)).ReturnsAsync((Skills)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<MagicMeleeException>(() => _skillsService.GetByCharacterIdAsync(1));
        Assert.IsType<CharacterNotFoundException>(exception.InnerException);
    }
}
