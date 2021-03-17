package JavaProject.src;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

/**
 * LaskeKirjaimet-luokka. Made with love <3
 */
public class LaskeKirjaimet {

    private ArrayList<Kirjain> kirjaimet = new ArrayList<>();


    /**
     * Muljaa kirjaimia kirjaimet-taulukossa. Lisää taulukkoon kirjaimen jos törmää uuteen kirjaimeen ja lisää lukumäärään yhden jos kirjain on jo olemassa.
     * @param etsittava etsittävä kirjain
     */
    public void muljaaKirjaimia(char etsittava) {

        for (Kirjain kirjain : kirjaimet) {

            if(kirjain.getKirjain() == etsittava) {

                kirjain.addLkm();
                return;

            }
        }

        lisaaKirjain(etsittava).addLkm();

    } 

    /**
     * Palauttaa löydettyjen kirjainten määrän.
     * @return kirjainten lukumäärä
     */
    public long kirjaintenMaara() {

        long klkm = 0;

        for (Kirjain kirjain : kirjaimet) {

            klkm += kirjain.getlkm();

        }
        return klkm;
    }

    /**
     * Lisää kirjain kirjaimiin.
     * @param lisattava
     * @return lisätty kirjain
     */
    private Kirjain lisaaKirjain(char lisattava) {

        Kirjain kirjain = new Kirjain(lisattava);
        kirjaimet.add(kirjain);
        jarjesta();
        return kirjain;

    }
    
    /**
     * Järjestää taulukon aakkosjärjestykseen.
     */
    private void jarjesta() {

        Collections.sort(kirjaimet);

    }

    /**
     * Tulostaa kirjaimet ja niiden määrät.
     */
    public void tulosta() {
        jarjesta();
        for (Kirjain kirjain : kirjaimet) {

            System.out.println(kirjain.toString());

        }

    }
    /**
     * Main
     * @param args tiedosto, joka luetaan
     */
    public static void main(String[] args) {

        LaskeKirjaimet kirjainlaskuri = new LaskeKirjaimet();
        String tiedLuettava = "input.txt";

        if (args.length > 0 ) {

            tiedLuettava = args[0];

        }

        long startTime = System.currentTimeMillis();
        try (Scanner fi = new Scanner(new FileInputStream(new File(tiedLuettava)))) {

            while ( fi.hasNext() ) {

                char[] rivi = fi.nextLine().toCharArray();

                for (char kirjain : rivi) {
                    
                    kirjainlaskuri.muljaaKirjaimia(Character.toLowerCase(kirjain));

                }
            }

        } catch (FileNotFoundException ex) {

            System.err.println("Tiedosto ei aukea! " + ex.getMessage());
            return;

        }
        long endTime = System.currentTimeMillis();
        kirjainlaskuri.tulosta();
        System.out.println("Kirjaimia " + kirjainlaskuri.kirjaintenMaara() + ", kesti " + (endTime - startTime) + "ms");

    }

    /**
     * Kirjain luokka.
     */
    private class Kirjain implements Comparable<Kirjain> {

        private int lkm;
        private char k;

        /**
         * Konstruktori
         * @param kirjain kirjain-olion kirjain.
         */
        public Kirjain(char kirjain) {

            this.lkm = 0;
            this.k = kirjain;

        }

        /**
         * Palauttaa tämän kirjain-olion lukumäärän
         * @return lukumäärä
         */
        public int getlkm() {

            return this.lkm;

        }

        /**
         * Palauttaa tämän kirjain-olion kirjaimen.
         * @return kirjain
         */
        public char getKirjain() {

            return this.k;

        }

        /**
         * Lisää kirjaimen lukumäärään yhden.
         */
        public void addLkm() {

            this.lkm++;

        }


        /**
         * Lisää kirjaimen lukumäärään lkm-arvon.
         * @param lkm lisättävä arvo
         */
        public void addLkm(int lkm) {

            this.lkm = this.lkm + lkm;

        }

        /**
         * Tulostaa kirjain-olion tiedot.
         */
        public String toString() {

            return this.getKirjain() + ": " + this.getlkm();

        }

        /**
         * Vertaillaan kirjain-olioita.
         * @param kirjain vertailtava kirjain
         * @return 1 jos isompi, -1 jos pienempi, muutoin 0
         */
        @Override
        public int compareTo(Kirjain kirjain) {

            if(this.getKirjain() > kirjain.getKirjain()) return 1;
            if(this.getKirjain() < kirjain.getKirjain()) return -1;
            return 0;

        }

    }
}
