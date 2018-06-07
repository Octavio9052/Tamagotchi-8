package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.PetDetailsViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * @author J. Pichardo
 */
public class PetDetailsView implements FxmlView<PetDetailsViewModel>, Initializable {
    @FXML
    public ImageView idleImageView;
    @FXML
    public Button idleBrowseButton;
    @FXML
    public ImageView playImageView;
    @FXML
    public Button playBrowseButton;
    @FXML
    public ImageView sleepImageView;
    @FXML
    public Button sleepBrowseButton;
    @FXML
    public ImageView eatImageView;
    @FXML
    public Button eatBrowseButton;
    @FXML
    public TextField nameField;
    @FXML
    public TextField descriptionField;
    @FXML
    public TextField packageField;
    @FXML
    public Button packageBrowseButton;
    @FXML
    public Button addPropButton;
    @FXML
    public TableView dynamicPropsTable;
    @FXML
    public TableColumn dynamicPropNameColumn;
    @FXML
    public TableColumn dynamicPropValueColumn;
    @FXML
    public Button createButton;

    public void initialize(URL location, ResourceBundle resources) {

    }
}
