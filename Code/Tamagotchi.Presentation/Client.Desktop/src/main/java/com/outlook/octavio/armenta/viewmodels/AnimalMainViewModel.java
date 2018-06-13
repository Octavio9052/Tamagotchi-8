package com.outlook.octavio.armenta.viewmodels;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import de.saxsys.mvvmfx.InjectViewModel;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;


public class AnimalMainViewModel implements ViewModel {

    private final IAuthService authService;
    private Command logoutCommand;

    @Inject
    public AnimalMainViewModel(IAuthService authService) {
        this.authService = authService;

        logoutCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doLogout();
            }
        });
    }

    public Command getLogoutCommand() {
        return logoutCommand;
    }

    private void doLogout() {
        this.authService.logout();
    }

}
