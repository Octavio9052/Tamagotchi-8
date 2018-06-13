package com.outlook.octavio.armenta.viewmodels;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import de.saxsys.mvvmfx.InjectViewModel;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;


public class AnimalMainViewModel implements ViewModel {

    private final IAuthService authService;
    private Command logoutCommand;
    private StringProperty username = new SimpleStringProperty();

    @Inject
    public AnimalMainViewModel(IAuthService authService) {
        this.authService = authService;

        logoutCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doLogout();
            }
        });

        username.set(this.authService.getUser().name);

    }

    public Command getLogoutCommand() {
        return logoutCommand;
    }

    private void doLogout() {
        this.authService.logout();
    }

    public StringProperty userNameProperty(){
        return username;
    }

    public String getUserName(){
        return username.get();
    }

}
