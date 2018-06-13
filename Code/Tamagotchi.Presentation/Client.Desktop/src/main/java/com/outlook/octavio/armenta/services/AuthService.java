package com.outlook.octavio.armenta.services;

import com.google.inject.Singleton;
import com.outlook.octavio.armenta.models.Login;
import com.outlook.octavio.armenta.models.User;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import com.outlook.octavio.armenta.ws.SOAPServiceStub;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginMessageRequest;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginModel;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.LoginMessageResponse;
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

            LoginMessageResponse loginMessageResponse = new LoginMessageResponse();

            SOAPServiceStub.UserModel userModel = loginMessageResponse.getUser();


            currentUser.GUID = loginResponse.getLoginResult().getUserToken().getGuid();
            currentUser.userId = loginResponse.getLoginResult().getUser().getId();
            currentUser.name = loginResponse.getLoginResult().getUser().getName();
            // currentUser.creations = loginResponse.getLoginResult().getUser().getCreations().getKeyValueOfintstring(x )
            this.user.set(currentUser);
        } catch (Exception e) {
            System.out.println();
            System.out.println(e.toString());
            System.out.println();
        }
    }

    @Override
    public void signUp(String username, String email, String password){
        Login newUser = new Login();
        try {
            SOAPServiceStub soapServiceStub = new SOAPServiceStub();

            LoginMessageRequest lmr = new LoginMessageRequest();
            LoginModel loginModel = new LoginModel();
            loginModel.setEmail(email);
            loginModel.setPassword(password);
            lmr.setName(username);
            lmr.setLogin(loginModel);

            SOAPServiceStub.CreateUser createUser = new SOAPServiceStub.CreateUser();
            createUser.setValue(lmr);

            //SOAPServiceStub.CreateUserResponse cuResponse = new


        } catch (Exception e){
            System.out.println();
            System.out.println(e.toString());
            System.out.println();
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
