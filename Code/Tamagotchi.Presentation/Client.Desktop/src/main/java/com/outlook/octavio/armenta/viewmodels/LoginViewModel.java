package com.outlook.octavio.armenta.viewmodels;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class LoginViewModel implements ViewModel {

    private final IAuthService authService;

    private StringProperty emailProperty = new SimpleStringProperty();
    private StringProperty passwordProperty = new SimpleStringProperty();

    private Command loginCommand;

    @Inject
    public LoginViewModel(IAuthService authService) {
        this.authService = authService;

        this.loginCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doLogin();
            }
        });

    }

    private void doLogin(){
        this.authService.login(emailProperty.get(), passwordProperty.get());
    }


    public String getEmailProperty() {
        return emailProperty.get();
    }

    public StringProperty emailPropertyProperty() {
        return emailProperty;
    }

    public String getPasswordProperty() {
        return passwordProperty.get();
    }

    public StringProperty passwordPropertyProperty() {
        return passwordProperty;
    }

    public Command getLoginCommand() {
        return loginCommand;
    }
}
