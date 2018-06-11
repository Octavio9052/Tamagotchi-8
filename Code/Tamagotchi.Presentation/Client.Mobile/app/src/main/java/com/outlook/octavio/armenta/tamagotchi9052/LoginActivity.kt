package com.outlook.octavio.armenta.tamagotchi9052

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import kotlinx.android.synthetic.main.activity_login.*

class LoginActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        login_button_sign_in.setOnClickListener { attempLogin() }
    }

    fun attempLogin() {
        if(checkCredential()){
            doLogin()
        }
        else {

        }
    }

    fun checkCredential(): Boolean {
        return true
    }

    fun doLogin() {
        var intent = Intent(this, MainActivity::class.java)
        startActivity(intent);
    }

    fun getToken() {

    }

    fun getUser() {

    }
}
