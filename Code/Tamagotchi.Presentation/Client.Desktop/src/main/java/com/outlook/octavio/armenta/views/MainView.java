package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.MainViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.collections.ListChangeListener;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Region;

import java.net.URL;
import java.util.ResourceBundle;

/**
 * @author J. Pichardo
 */
public class MainView implements FxmlView<MainViewModel>, Initializable {
    @FXML
    public AnchorPane mainPane;

    public void initialize(URL location, ResourceBundle resources) {

        adaptChildren();

        mainPane.getChildren().addListener((ListChangeListener<? super Node>) listener -> adaptChildren());

    }

    private void adaptChildren() {
        ((Region) mainPane.getChildren().get(0)).prefWidthProperty().bind(mainPane.widthProperty());
        ((Region) mainPane.getChildren().get(0)).prefHeightProperty().bind(mainPane.heightProperty());
    }
}
