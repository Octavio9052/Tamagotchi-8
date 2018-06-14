package com.outlook.octavio.armenta.tamagotchi9052.web.services

import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginRequest
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.LoginResponse
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.POST


interface LoginService {

    @POST("login/")
    fun Login(@Body request: LoginRequest): Call<LoginResponse>

    @POST("user/create")
    fun Register(@Body request: LoginRequest): Call<LoginResponse>

}
