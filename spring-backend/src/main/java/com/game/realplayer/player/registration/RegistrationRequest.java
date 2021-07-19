package com.game.realplayer.player.registration;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.ToString;

@ToString
@AllArgsConstructor
@Data
public class RegistrationRequest {
    private final String firstname;
    private final String lastname;
    private final String email;
    private final String password;
}
