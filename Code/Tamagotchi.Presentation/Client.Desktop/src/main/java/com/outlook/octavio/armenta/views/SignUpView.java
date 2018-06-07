package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.MainViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.TextField;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * @author J. Pichardo
 */
public class SignUpView implements FxmlView<MainViewModel>, Initializable {

    @FXML
    public TextField usernameField;
    @FXML
    public TextField emailField;
    @FXML
    public TextField passwordField;
    @FXML
    public TextField passwordConfirmationField;
    @FXML
    public CheckBox termsCheckbox;
    @FXML
    public Button signUpButton;

    public void initialize(URL location, ResourceBundle resources) {

    }
}
