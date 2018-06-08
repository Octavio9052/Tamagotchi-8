package com.outlook.octavio.armenta.views;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.viewmodels.AnimalDetailsViewModel;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import javafx.beans.property.SimpleListProperty;
import javafx.beans.property.StringProperty;
import javafx.collections.FXCollections;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.TextFieldTableCell;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.net.URL;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.function.Consumer;

import static com.outlook.octavio.armenta.viewmodels.AnimalDetailsViewModel.*;

public class AnimalDetailsView implements FxmlView<AnimalDetailsViewModel>, Initializable {
    @FXML
    public ImageView idleImageView;
    @FXML
    public ImageView playImageView;
    @FXML
    public ImageView sleepImageView;
    @FXML
    public ImageView eatImageView;

    @FXML
    public TextField nameField;
    @FXML
    public TextField descriptionField;
    @FXML
    public TextField packageField;
    @FXML
    public TextField propNameField;

    @FXML
    public TableView<Map.Entry<StringProperty, StringProperty>> dynamicPropsTable;
    @FXML
    public TableColumn<Map.Entry<StringProperty, StringProperty>, String> dynamicPropNameColumn;
    @FXML
    public TableColumn<Map.Entry<StringProperty, StringProperty>, String> dynamicPropValueColumn;

    @FXML
    public Button idleBrowseButton;
    @FXML
    public Button playBrowseButton;
    @FXML
    public Button sleepBrowseButton;
    @FXML
    public Button eatBrowseButton;
    @FXML
    public Button packageBrowseButton;
    @FXML
    public Button addPropButton;
    @FXML
    public Button createButton;

    @Inject
    private Stage stage;

    @InjectViewModel
    private AnimalDetailsViewModel viewModel;

    public void initialize(URL location, ResourceBundle resources) {


        viewModel.dynamicPropsProperty().addListener((observable, oldValue, newValue) -> {
            SimpleListProperty<Map.Entry<StringProperty, StringProperty>> items = new SimpleListProperty<>(FXCollections.observableArrayList());

            items.addAll(newValue.entrySet());
            dynamicPropsTable.itemsProperty().setValue(items);
        });

        dynamicPropNameColumn.setCellValueFactory(param -> param.getValue().getKey());
        dynamicPropValueColumn.setCellValueFactory(param -> param.getValue().getValue());
        dynamicPropNameColumn.setCellFactory(TextFieldTableCell.forTableColumn());
        dynamicPropValueColumn.setCellFactory(TextFieldTableCell.forTableColumn());


        idleImageView.imageProperty().bind(viewModel.idleImageProperty());
        playImageView.imageProperty().bind(viewModel.playImageProperty());
        sleepImageView.imageProperty().bind(viewModel.sleepImageProperty());
        eatImageView.imageProperty().bind(viewModel.eatImageProperty());

        nameField.textProperty().bindBidirectional(viewModel.nameFieldProperty());
        descriptionField.textProperty().bindBidirectional(viewModel.descriptionFieldProperty());
        packageField.textProperty().bindBidirectional(viewModel.packageFieldProperty());
        propNameField.textProperty().bindBidirectional(viewModel.propNameProperty());

        idleBrowseButton.setOnAction(e -> viewModel.getIdleBrowseCommand().execute());
        playBrowseButton.setOnAction
                (e -> viewModel.getPlayBrowseCommand().execute());
        sleepBrowseButton.setOnAction(e -> viewModel.getSleepBrowseCommand().execute());
        eatBrowseButton.setOnAction(e -> viewModel.getEatBrowseCommand().execute());
        packageBrowseButton.setOnAction(e -> viewModel.getPackageBrowseCommand().execute());
        addPropButton.setOnAction(e -> viewModel.getAddPropCommand().execute());
        createButton.setOnAction(e -> viewModel.getCreateCommand().execute());

        viewModel.subscribe(IDLE_BROWSE, (s, objects) -> {
            FileChooser.ExtensionFilter filter = new FileChooser.ExtensionFilter("Images", "*.jpg", "*.png");

            this.openFileChooser(filter, file -> {
                viewModel.idleImageProperty().setValue(new Image(file.toURI().toString()));
            });
        });
        viewModel.subscribe(PLAY_BROWSE, (s, objects) -> {
            FileChooser.ExtensionFilter filter = new FileChooser.ExtensionFilter("Images", "*.jpg", "*.png");

            this.openFileChooser(filter, file -> {
                viewModel.playImageProperty().setValue(new Image(file.toURI().toString()));
            });
        });
        viewModel.subscribe(SLEEP_BROWSE, (s, objects) -> {
            FileChooser.ExtensionFilter filter = new FileChooser.ExtensionFilter("Images", "*.jpg", "*.png");

            this.openFileChooser(filter, file -> {
                viewModel.sleepImageProperty().setValue(new Image(file.toURI().toString()));
            });
        });
        viewModel.subscribe(EAT_BROWSE, (s, objects) -> {
            FileChooser.ExtensionFilter filter = new FileChooser.ExtensionFilter("Images", "*.jpg", "*.png");

            this.openFileChooser(filter, file -> {
                viewModel.eatImageProperty().setValue(new Image(file.toURI().toString()));
            });
        });
        viewModel.subscribe(PACKAGE_BROWSE, (s, objects) -> {
            FileChooser.ExtensionFilter filter = new FileChooser.ExtensionFilter("Animal Package", "*.dll");

            this.openFileChooser(filter, file -> {
                viewModel.packagePropertyProperty().setValue(file);
                viewModel.packageFieldProperty().setValue(file.getName());
            });
        });
    }

    private void openFileChooser(FileChooser.ExtensionFilter filter, Consumer<File> callback) {

        FileChooser fileChooser = new FileChooser();
        fileChooser.getExtensionFilters().add(filter);
        File file = fileChooser.showOpenDialog(stage);
        callback.accept(file);
    }

}
