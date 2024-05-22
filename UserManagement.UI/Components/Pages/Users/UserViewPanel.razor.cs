using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using UserManagement.UserApi.Models;

namespace UserManagement.UI.Components.Pages.Users;

public partial class UserViewPanel : IDialogContentComponent
{
    [Parameter]
    public UserEntity Content { get; set; } = default!;

    bool isBusy;

    protected override async Task OnInitializedAsync()
    {
        isBusy = false;
    }
}