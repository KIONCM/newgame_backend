package com.game.realplayer.player.registration;

import com.game.realplayer.player.Player;
import com.game.realplayer.player.PlayerService;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class RegistrationService {
    private final PlayerService playerService;

    public String register(RegistrationRequest request) {
        return playerService.signUp(
                new Player(
                        request.getFirstname(),
                        request.getLastname(),
                        request.getEmail(),
                        request.getPassword()

                )
        );
    }
}
