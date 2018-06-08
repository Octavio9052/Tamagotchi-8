package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.AuthViewModel;
import com.outlook.octavio.armenta.viewmodels.MainViewModel;
import com.outlook.octavio.armenta.viewmodels.AnimalMainViewModel;
import de.saxsys.mvvmfx.FluentViewLoader;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import de.saxsys.mvvmfx.ViewTuple;
import javafx.collections.ListChangeListener;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Region;

import javax.annotation.PostConstruct;
import java.net.URL;
import java.util.ResourceBundle;

public class MainView implements FxmlView<MainViewModel>, Initializable {
    @FXML
    public AnchorPane mainPane;

    @InjectViewModel
    MainViewModel viewModel;

    public void initialize(URL location, ResourceBundle resources) {

        adaptChildren();

        mainPane.getChildren().addListener((ListChangeListener<? super Node>) listener -> adaptChildren());

        viewModel.subscribe(MainViewModel.LOGIN_VIEW, (s, objects) -> {
            ViewTuple<AuthView, AuthViewModel> tuple = FluentViewLoader.fxmlView(AuthView.class).load();

            mainPane.getChildren().clear();
            mainPane.getChildren().add(tuple.getView());
        });

        viewModel.subscribe(MainViewModel.ANIMAL_VIEW, (s, objects) -> {
            ViewTuple<AnimalMainView, AnimalMainViewModel> tuple = FluentViewLoader.fxmlView(AnimalMainView.class).load();

            mainPane.getChildren().clear();
            mainPane.getChildren().add(tuple.getView());
        });

    }


    @PostConstruct
    public void postConstruct() {
        adaptChildren();
    }

    private void adaptChildren() {

        if(mainPane.getChildren().size() < 1) return;

        ((Region) mainPane.getChildren().get(0)).prefWidthProperty().bind(mainPane.widthProperty());
        ((Region) mainPane.getChildren().get(0)).prefHeightProperty().bind(mainPane.heightProperty());
    }
}
