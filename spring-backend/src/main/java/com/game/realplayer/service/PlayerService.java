package com.game.realplayer.service;

import com.game.realplayer.entity.player.Player;
import com.game.realplayer.repository.PlayerRepo;
import lombok.AllArgsConstructor;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class PlayerService  implements UserDetailsService {


    private final PlayerRepo playerRepo;
    private final BCryptPasswordEncoder bCryptPasswordEncoder;
    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException {
        return playerRepo.findByEmail(email)
                .orElseThrow(()-> new UsernameNotFoundException("NOt Found"));
    }

    public String signUp(Player player){
       boolean userExists =  playerRepo.findByEmail(player.getEmail())
                .isPresent();
       if (userExists){
           throw new IllegalStateException("already token");
       }
      String encodedPassword = bCryptPasswordEncoder.encode(player.getPassword());
       player.setPassword(encodedPassword);
        playerRepo.save(player);
        return "it works";
    }

}
