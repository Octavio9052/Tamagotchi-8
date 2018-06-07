package com.outlook.octavio.armenta.services.contracts;

import com.outlook.octavio.armenta.models.Login;
import javafx.beans.property.ObjectProperty;

public interface IAuthService {
    void login(String username, String password);

    void logout();

    Login getUser();

    void setUser(Login user);

    ObjectProperty<Login> userProperty();
}
