package com.outlook.octavio.armenta.tamagotchi9052.web.services

import retrofit2.Call
import retrofit2.http.POST

/**
 * @author J. Pichardo
 */
interface LoginService {

    @POST("login/")
    fun Login(request: LoginRequest): Call<LoginResponse>

}
