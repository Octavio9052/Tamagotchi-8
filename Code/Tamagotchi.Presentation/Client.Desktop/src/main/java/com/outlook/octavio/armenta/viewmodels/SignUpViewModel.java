package com.outlook.octavio.armenta.viewmodels;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.BooleanProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class SignUpViewModel implements ViewModel {

    private final IAuthService authService;

    private StringProperty username = new SimpleStringProperty();
    private StringProperty email = new SimpleStringProperty();
    private StringProperty password = new SimpleStringProperty();
    private StringProperty passwordConfirmation = new SimpleStringProperty();

    private BooleanProperty terms = new SimpleBooleanProperty();

    private Command signUpCommand;

    @Inject
    public SignUpViewModel(IAuthService authService) {
        this.authService = authService;

        signUpCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doSignUp();
            }
        });

    }

    private void doSignUp() {
        this.authService.login(email.get(), password.get());
    }

    public String getUsername() {
        return username.get();
    }

    public StringProperty usernameProperty() {
        return username;
    }

    public String getEmail() {
        return email.get();
    }

    public StringProperty emailProperty() {
        return email;
    }

    public String getPassword() {
        return password.get();
    }

    public StringProperty passwordProperty() {
        return password;
    }

    public String getPasswordConfirmation() {
        return passwordConfirmation.get();
    }

    public StringProperty passwordConfirmationProperty() {
        return passwordConfirmation;
    }

    public boolean isTerms() {
        return terms.get();
    }

    public BooleanProperty termsProperty() {
        return terms;
    }

    public Command getSignUpCommand() {
        return signUpCommand;
    }
}
