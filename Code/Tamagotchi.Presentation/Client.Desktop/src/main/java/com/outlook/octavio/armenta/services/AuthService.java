package com.outlook.octavio.armenta.services;

import com.google.inject.Singleton;
import com.outlook.octavio.armenta.models.Login;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleObjectProperty;

@Singleton
public class AuthService implements IAuthService {

    public ObjectProperty<Login> user = new SimpleObjectProperty<>();

    @Override
    public void login(String username, String password) {
        Login user = new Login();

        user.email = username;
        user.password = password;

        this.user.setValue(user);
    }

    public void logout(){
        this.user.setValue(null);
    }

    @Override
    public Login getUser() {
        return user.get();
    }

    @Override
    public void setUser(Login user) {
        this.user.set(user);
    }

    @Override
    public ObjectProperty<Login> userProperty() {
        return user;
    }
}
