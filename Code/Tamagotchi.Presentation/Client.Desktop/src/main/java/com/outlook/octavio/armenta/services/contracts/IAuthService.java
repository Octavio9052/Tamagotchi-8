package com.outlook.octavio.armenta.services.contracts;

import com.outlook.octavio.armenta.models.Login;
import com.outlook.octavio.armenta.models.User;
import javafx.beans.property.ObjectProperty;

public interface IAuthService {
    void login(String username, String password);

    void logout();

    User getUser();

    void setUser(User user);

    ObjectProperty<User> userProperty();

    void signUp(String username, String email, String password);
}
