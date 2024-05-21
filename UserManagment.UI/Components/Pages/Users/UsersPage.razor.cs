using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.FluentUI.AspNetCore.Components;
using UserManagment.UI.Services.Contracts;
using UserManagment.UserApi.Models;

namespace UserManagment.UI.Components.Pages.Users;

public partial class UsersPage : BasePage
{
    [Inject]
    public required IUserService Service { get; set; }

    private IQueryable<UserEntity>? _users;

    private IDialogReference? _dialog;

    protected override async Task OnInitializedAsync()
    {
        await LoadUsers();
    }

    private async Task LoadUsers()
    {
        _users = (await Service.GetAllUsersAsync()).AsQueryable();
    }

    private async Task OnAddNewUserClick()
    {
        var panelTitle = $"Add a user";
        var result = await ShowPanel(panelTitle, new UserEntity() { DateOfBirth = DateTime.Parse("1990-01-01"), IsActive = false }, true);
        if (result.Cancelled)
        {
            return;
        }
        var entity = result.Data as UserEntity;
        ShowProgressToast(nameof(OnAddNewUserClick), "User", entity!.Name);
        _ = await Service.AddUserAsync(entity!);
        CloseProgressToast(nameof(OnAddNewUserClick));
        ShowSuccessToast("User", entity!.Name);
        await LoadUsers();
    }



    private async Task OnEditUserClick(UserEntity user)
    {
        var panelTitle = $"Edit user";
        var result = await ShowPanel(panelTitle, user, false);
        if (result.Cancelled)
        {
            return;
        }
        var entity = result.Data as UserEntity;
        ShowProgressToast(nameof(OnEditUserClick), "User", entity!.Name, Operation.Update);
        await Service.UpdateUserAsync(entity!);
        CloseProgressToast(nameof(OnEditUserClick));
        ShowSuccessToast("User", entity!.Name, Operation.Update);
        await LoadUsers();
    }

    private async Task OnDeleteUserClick(UserEntity entity)
    {
        var confirm = await ShowConfirmationDialogAsync("Delete User", $"Are you sure you want to delete {entity.Name}?");
        if (confirm.Cancelled)
        {
            return;
        }
        ShowProgressToast(nameof(OnDeleteUserClick), "User", entity.Name, Operation.Delete);
        await Service.DeleteUserAsync(entity);
        CloseProgressToast(nameof(OnDeleteUserClick));
        ShowSuccessToast("User", entity.Name, Operation.Delete);
        await LoadUsers();
    }
    private async Task OnViewUserClick(UserEntity user)
    {
        var panelTitle = $"View user";
        var result = await ShowPanel(panelTitle, user);
        if (result.Cancelled)
        {
            return;
        }
        await LoadUsers();
    }

    private async Task<DialogResult> ShowPanel(string title, UserEntity user, bool isAdd)
    {
        var primaryActionText = isAdd ? "Add" : "Save changes";
        var dialogParameter = new DialogParameters<UserEntity>()
        {
            Content = user,
            Alignment = HorizontalAlignment.Right,
            Title = title,
            PrimaryAction = primaryActionText,
            Width = "500px",
            PreventDismissOnOverlayClick = true
        };
        _dialog = await DialogService.ShowPanelAsync<UserUpsertPanel>(user, dialogParameter);
        return await _dialog.Result;
    }
    
    private async Task<DialogResult> ShowPanel(string title, UserEntity user)
    {
        var primaryActionText = "Ok";
        var dialogParameter = new DialogParameters<UserEntity>()
        {
            Content = user,
            Alignment = HorizontalAlignment.Right,
            Title = title,
            PrimaryAction = primaryActionText,
            Width = "500px",
            PreventDismissOnOverlayClick = true
        };
        _dialog = await DialogService.ShowPanelAsync<UserViewPanel>(user, dialogParameter);
        return await _dialog.Result;
    }
}
