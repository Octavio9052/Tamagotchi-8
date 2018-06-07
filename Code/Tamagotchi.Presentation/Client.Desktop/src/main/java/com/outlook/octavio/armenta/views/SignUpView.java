package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.SignUpViewModel;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;

import java.net.URL;
import java.util.ResourceBundle;

public class SignUpView implements FxmlView<SignUpViewModel>, Initializable {

    @FXML
    public TextField usernameField;
    @FXML
    public TextField emailField;
    @FXML
    public PasswordField passwordField;
    @FXML
    public PasswordField passwordConfirmationField;
    @FXML
    public CheckBox termsCheckbox;
    @FXML
    public Button signUpButton;

    @InjectViewModel
    private SignUpViewModel viewModel;

    public void initialize(URL location, ResourceBundle resources) {
        usernameField.textProperty().bindBidirectional(viewModel.usernameProperty());
        emailField.textProperty().bindBidirectional(viewModel.emailProperty());
        passwordField.textProperty().bindBidirectional(viewModel.passwordProperty());
        passwordConfirmationField.textProperty().bindBidirectional(viewModel.passwordConfirmationProperty());
        termsCheckbox.selectedProperty().bindBidirectional(viewModel.termsProperty());

        signUpButton.setOnAction(e -> viewModel.getSignUpCommand().execute());
        signUpButton.disableProperty().bind(viewModel.getSignUpCommand().executableProperty().not());

    }
}
