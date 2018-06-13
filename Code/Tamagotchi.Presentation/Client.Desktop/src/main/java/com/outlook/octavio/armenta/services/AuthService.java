package com.outlook.octavio.armenta.services;

import com.google.inject.Singleton;
import com.outlook.octavio.armenta.models.Login;
import com.outlook.octavio.armenta.models.User;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import com.outlook.octavio.armenta.ws.SOAPServiceStub;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginMessageRequest;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginModel;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleObjectProperty;

@Singleton
public class AuthService implements IAuthService {

    public ObjectProperty<User> user = new SimpleObjectProperty<>();

    @Override
    public void login(String username, String password) {
        Login user = new Login();
        User currentUser = new User();

        user.email = username;
        user.password = password;

        // TODO: HERE DOES THE LOGIN
        try {
            SOAPServiceStub soapServiceStub = new SOAPServiceStub();

            LoginMessageRequest loginMessageRequest = new LoginMessageRequest();
            LoginModel loginModel = new LoginModel();
            loginModel.setEmail(user.email);
            loginModel.setPassword(user.password);
            loginMessageRequest.setLogin(loginModel);
            SOAPServiceStub.Login login2 = new SOAPServiceStub.Login();
            login2.setValue(loginMessageRequest);


            SOAPServiceStub.LoginResponse loginResponse = soapServiceStub.login(login2);


            currentUser.GUID = loginResponse.getLoginResult().getUserToken().getGuid();
            currentUser.userId = loginResponse.getLoginResult().getUser().getId();
            currentUser.name = loginResponse.getLoginResult().getUser().getName();
            // currentUser.creations = loginResponse.getLoginResult().getUser().getCreations().getKeyValueOfintstring(x )

            System.out.println("GUID: " + currentUser.GUID);
            System.out.println("UserId: " + currentUser.userId);
            System.out.println("Name: " + currentUser.name);

            this.user.set(currentUser);
        } catch (Exception e) {
            System.out.println();
            System.out.println(e.toString());
        }
    }

    @Override
    public void signUp(String username, String email, String password){
        User newUser = new User();
        try {
            SOAPServiceStub soapServiceStub = new SOAPServiceStub();

            LoginMessageRequest lmRequest = new LoginMessageRequest();
            LoginModel loginModel = new LoginModel();
            loginModel.setEmail(email);
            loginModel.setPassword(password);
            lmRequest.setName(username);
            lmRequest.setLogin(loginModel);
            SOAPServiceStub.CreateUser createUser = new SOAPServiceStub.CreateUser();
            createUser.setValue(lmRequest);


            SOAPServiceStub.CreateUserResponse cuResponse = soapServiceStub.createUser(createUser);



            System.out.println("Name: " + cuResponse.getCreateUserResult().getUser().getName());
            System.out.println("ID: " + cuResponse.getCreateUserResult().getUser().getId());
            System.out.println("Token: " + cuResponse.getCreateUserResult().getUserToken().getGuid());

            newUser.GUID = cuResponse.getCreateUserResult().getUserToken().getGuid();
            newUser.name = cuResponse.getCreateUserResult().getUser().getName();
            newUser.userId = cuResponse.getCreateUserResult().getUser().getId();

            this.user.set(newUser);
        } catch (Exception e){
            System.out.println();
            System.out.println(e.toString());
        }
    }

    public void logout(){
        this.user.setValue(null);
    }

    @Override
    public User getUser() {
        return this.user.get();
    }

    @Override
    public void setUser(User user) {
        this.user.set(user);
    }

    @Override
    public ObjectProperty<User> userProperty() {
        return user;
    }
}
