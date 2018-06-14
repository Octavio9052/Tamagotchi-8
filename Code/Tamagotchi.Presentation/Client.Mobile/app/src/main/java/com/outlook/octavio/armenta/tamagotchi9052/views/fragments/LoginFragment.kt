package com.outlook.octavio.armenta.tamagotchi9052.views.fragments

import android.content.Intent
import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.models.Animal
import com.outlook.octavio.armenta.tamagotchi9052.models.Login
import com.outlook.octavio.armenta.tamagotchi9052.views.activities.MainActivity
import com.outlook.octavio.armenta.tamagotchi9052.views.activities.StoreActivity
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginRequest
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginResponse
import com.outlook.octavio.armenta.tamagotchi9052.web.services.LoginService
import com.outlook.octavio.armenta.tamagotchi9052.web.services.WebServiceFactory
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class LoginFragment : Fragment() {


    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_login, parent, false)
    }

    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // EditText etFoo = (EditText) view.findViewById(R.id.etFoo);
        super.onViewCreated(view, savedInstanceState)
        // petImageState = view.findViewById(R.id.state_image_pet)

        view.findViewById<Button>(R.id.login_button_sign_in).setOnClickListener {
            val email = view.findViewById<EditText>(R.id.login_input_email).text.toString()
            val paswd = view.findViewById<EditText>(R.id.login_input_password).text.toString()
            attempLogin(email, paswd)
        }
    }

    fun attempLogin(email: String, paswd: String) {
        try {/*
            val login = Login(email, paswd)
            val webServiceFactory = WebServiceFactory().getService(LoginService::class.java)

            val repos = webServiceFactory?.Login(LoginRequest(login, ""))?.enqueue(object : Callback<LoginResponse> {
                override fun onFailure(call: Call<LoginResponse>?, t: Throwable?) {
                    Toast.makeText(context, "Wrong credentials", Toast.LENGTH_LONG).show()
                }

                override fun onResponse(call: Call<LoginResponse>?, response: Response<LoginResponse>?) {
                    doLogin()
                }

            })*/
        } catch (e: Exception) {
            doLogin()
        }
        doLogin()

    }

    fun doLogin() {
        val intent = Intent(activity, StoreActivity::class.java)
        startActivity(intent)
    }

    fun getToken() {

    }

    fun getUser() {

    }
}
